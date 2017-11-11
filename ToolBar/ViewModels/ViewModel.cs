using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToolBar.Helpers;
using System.Windows;
using System.IO;
using ToolBar.Models;
using ToolBar.DataAccess;
using System.Windows.Media.Imaging;
using System.Diagnostics;


namespace ToolBar.ViewModels
{
    public class ViewModel : NotifyProperyChangedClass
    {
        public ICommand DragCommand { get; set; }
        public ICommand ClickStartCommand { get; set; }
        private IModelList _modelList;
        private IXamlScriptGenerator _xamlscriptgenerator;
        private Item _SelectedItem;
        public Item SelectedItem
        {
            get
            {
                return _SelectedItem;
            }
            set
            {
                if(_SelectedItem!=value)
                {
                    _SelectedItem = value;
                    StartApplication(value);
                    onPropertyChanged();
                }
            }
        }
        private const string datafile = @".\Data\DataXml.xml";
        public ObservableCollection<Item> ItemsCollection { get; set; }
        
        public ViewModel(IModelList list,IXamlScriptGenerator generator)
        {
            _modelList = list;
            _xamlscriptgenerator = generator;
            ItemsCollection = new ObservableCollection<Item>(_xamlscriptgenerator.GetData(datafile).Select(
                x => new Item { Path = x.Path, Image = _modelList.GetBitmap(x.Image),Name = x.Name }).ToList());
            DragCommand = new RelayCommand(Execute,CanExecute);
            ClickStartCommand = new RelayCommand(StartApplication, CanExecute);
        }

       
        private void Execute(object parametr)
        {
            IDataObject idata = parametr as IDataObject;
                if (idata != null)
                {
                    string[] path = (string[])idata.GetData(DataFormats.FileDrop,true);
                    if (path != null)
                    {
                        
                        string directoryfile = @".\Icons\";
                        if (File.Exists(path[0]))
                        {
                            string filename = Path.GetFileName(path[0]);
                       
                            directoryfile += filename + ".ico";
                            _modelList.SaveIcon(path[0], directoryfile);
                            ItemsCollection.Add(new Item { Path = path[0], Image = _modelList.GetBitmap(filename + ".ico"), Name = Path.GetFileNameWithoutExtension(path[0]) });
                            _xamlscriptgenerator.SaveData(datafile,path[0], filename + ".ico",Path.GetFileNameWithoutExtension(path[0]));
                        }
                        else if (Directory.Exists(path[0]))
                        {
                            string filename = new DirectoryInfo(path[0]).Name;
                            directoryfile += filename + ".ico";
                            _modelList.SaveIcon(directoryfile, Properties.Resources.folder);
                            ItemsCollection.Add(new Item { Path = path[0], Image = _modelList.GetBitmap(filename+".ico"),Name = filename });
                            _xamlscriptgenerator.SaveData(datafile,path[0], filename + ".ico",filename);
                        }
                    }
                    else MessageBox.Show("Invalid operaiton. You can't add to the ToolBar: Desktop or Basket.","Error!");
                }
        }

        private void StartApplication(object path)
        {
            try
            {
                Process newProc = Process.Start(_SelectedItem.Path);
                newProc.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private bool CanExecute(object canexecute)
        {
            return true;
        }
    }
}
