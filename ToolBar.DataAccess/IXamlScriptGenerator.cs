using System.Collections.Generic;

namespace ToolBar.DataAccess
{
    /// <summary>
    /// Business logic for data access
    /// </summary>
   public interface IXamlScriptGenerator
   {

       /// <summary>
       /// Saves a new data in a file. Creates a new fie, if file does not exists
       /// </summary>
       /// <param name="pathfile">File for data</param>
       /// <param name="path">The path of the file, that you want to save</param>
       /// <param name="image">The icon of the file, that you want to save</param>
       /// <param name="namefile">The name of the file, that you want to save</param>
       void SaveData(string pathfile, string path, string image, string namefile);
       /// <summary>
       /// Extracts data from the file, and converts it to a collection of items
       /// </summary>
       /// <param name="pathfile">Way to data file</param>
       /// <returns></returns>
        IEnumerable<Items> GetData(string pathfile);
       
    }
}
