using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NODO
{


    [Serializable]
    public class Nodo
    {

        public List<EndPointGroup> endPointGroups { get; set; }
        string configFileName;


        public Nodo() { }

        public EndPointGroup GetGroup(string groupName)
        {
            foreach (EndPointGroup endPointGroup in endPointGroups)
            {
                if (endPointGroup.Name.ToLower() == groupName.ToLower())
                {
                    return endPointGroup;
                }
            }
            return null;
        }

        public Nodo(string Name, string Path)
        {
            if (Path != null) { 
            configFileName = Path + "\\" + Name + ".json";
                if (File.Exists(configFileName) == true)
                {
                    string configFileContent = File.ReadAllText(configFileName);
                    endPointGroups = JsonConvert.DeserializeObject<Nodo>(configFileContent).endPointGroups;
                }
                else
                {
                File.Create(configFileName).Close();
                File.AppendAllText(configFileName, JsonConvert.SerializeObject(this));

                }
            }
        }

        
        public void SaveFile()
        {
            File.Create(configFileName).Close();
            
            File.AppendAllText(configFileName, JsonConvert.SerializeObject(this));
        }


        


        public void AddGroup(string groupName)
        {
            if (endPointGroups == null) endPointGroups = new List<EndPointGroup>();
            
            endPointGroups.Add(new EndPointGroup(groupName));
            SaveFile();
            
        }

        public void RemoveGroup(string groupName)
        {
            foreach (EndPointGroup PointerEndPointGroup in endPointGroups)
            {
                if (PointerEndPointGroup.Name.ToLower() == groupName.ToLower())
                {
                    endPointGroups.Remove(PointerEndPointGroup);
                    break;
                }
            }
            SaveFile();
        }

        public void AddEndPoint(string groupName, string uri)
        {
            bool flag = false;
            foreach (EndPointGroup PointerEndPointGroup in endPointGroups)
            {
                if (PointerEndPointGroup.Name.ToLower() == groupName.ToLower())
                {
                    PointerEndPointGroup.AddEndPoint(uri);
                    flag = true;
                    break;
                }
                if (flag) break;
            }
            SaveFile();
        }

        

        public void RemoveEndPoint(string groupName, string uri)
        {
            foreach (EndPointGroup PointerEndPointGroup in endPointGroups)
            {
                if (PointerEndPointGroup.Name.ToLower() == groupName.ToLower())
                {
                    foreach (EndPoint PointerEndPoint in PointerEndPointGroup.endPointList)
                    {
                        if (PointerEndPoint.URI == uri)
                        {
                            PointerEndPointGroup.endPointList.Remove(PointerEndPoint);
                                break;
                        }
                    }
                    
                }
            }
            SaveFile();
        }

    }
}
