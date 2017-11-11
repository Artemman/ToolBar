using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ToolBar.Models
{
    public interface IModelList
    {
        /// <summary>
        /// Load the icons from folder with icons(.\Icons\)
        /// </summary>
        /// <param name="path">path to file</param>
        /// <returns></returns>
        BitmapImage GetBitmap(string path);
        /// <summary>
        /// Extract the icon with the file and save it in a directory
        /// </summary>
        /// <param name="path"> path to file</param>
        /// <param name="directory">path to directory</param>
        void SaveIcon(string path, string directory);
        /// <summary>
        ///  Extract  the icon from folder saves it in a directory
        /// </summary>
        /// <param name="path">path to file</param>
        /// <param name="image"></param>
        void SaveIcon(string path, Icon image);
       
       
    }
}
