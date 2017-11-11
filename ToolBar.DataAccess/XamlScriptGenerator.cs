using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ToolBar.DataAccess
{
    /// <summary>
    /// Implementation for IXamlScriptGenerator
    /// </summary>
    public class XamlScriptGenerator : IXamlScriptGenerator
    {
        #region Methods
       public void SaveData(string pathfile,string path, string image,string namefile)
        {
           if (File.Exists(pathfile))
            {
                XDocument document = XDocument.Load(pathfile);
                int maxID = document.Root.Elements("Item").Max(x => Int32.Parse(x.Attribute("Id") == null ? "0" : x.Attribute("Id").Value));
                if (maxID == 0)
                {
                    document.Root.Element("Item").Remove();
                }
                XElement Item = new XElement("Item", new XAttribute("Id", ++maxID), new XAttribute("Path", path), new XAttribute("Image", image),new XAttribute("Name",namefile));
                document.Root.Add(Item);
                document.Save(pathfile);
            }
            else
            {
                XDocument document = new XDocument(new XElement("DataItems",
                    new XElement("Item", new XAttribute("Id", 0), new XAttribute("Path", path), new XAttribute("Image", image), new XAttribute("Name",namefile))));
                document.Save(pathfile);
            }
        }
       
        public IEnumerable<Items> GetData(string pathfile)
        {
            if (File.Exists(pathfile))
            {
                XDocument doc = XDocument.Load(pathfile);
                var listitems = doc.Root.Elements("Item").Select(x => new Items { Id = Int32.Parse(x.Attribute("Id").Value), Image = x.Attribute("Image").Value, Path = x.Attribute("Path").Value, Name = x.Attribute("Name").Value });
                return listitems;
            }
            else return new List<Items>();
        }
     
        #endregion Methods
    }
}
