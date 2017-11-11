using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows;

namespace ToolBar.Models
{
   public class ModelList : IModelList
    {
        public BitmapImage GetBitmap(string path)
        {
            Uri uri = new Uri(Directory.GetCurrentDirectory()+"/Icons/"+path, UriKind.Absolute);
            try
            {
                BitmapImage bi = new BitmapImage(uri);
                return bi;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("The "+path+" file could not be found!");
            }
            return null;
        }

        public void SaveIcon(string path, string directory)
        {
            Bitmap icon = Icon.ExtractAssociatedIcon(path).ToBitmap();
                icon.Save(directory);
        }
        public void SaveIcon(string directory, Icon image)
        {
            Icon icon = image;
            try
            {
                using (FileStream fs = new FileStream(directory, FileMode.Create))
                    icon.Save(fs);
            }
            catch(NotSupportedException)
            {
                MessageBox.Show("Invalid operaiton. You can't add to the ToolBar: Disk","Error!");
            }
        }
    }
}
