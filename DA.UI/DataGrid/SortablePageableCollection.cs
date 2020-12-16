using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using DA.SS;

namespace DA.UI.DataGrid
{
    public class SortablePageableCollection<T> : PageableCollection<T>, ISortable
    {
        public SortablePageableCollection(IEnumerable<T> allObjects, int? entriesPerPage = null)
            : base(allObjects, entriesPerPage)
        {
        }

        public IList GetAllObjects()
        {
            IList lst = new List<T>();

            foreach (T obj in AllObjects)
            {
                lst.Add(obj);
            }

            return lst;
        }

        public void Sort(string propertyName, string direction)
        {
            
            PropertyInfo prop;
            string[] arrProp = propertyName.Split('.');

            if (arrProp.Length > 1)
            {   
                //Type.GetType("DA.BE.Usuario, DA.BE")
                //Type tipoBase = Type.GetType("DA.BE."+arrProp[0]+", DA.BE");
               // prop = tipoBase.GetRuntimeProperty(arrProp[1]);
                prop = typeof(T).GetProperty(arrProp[0]);

            }
            else
                prop = typeof(T).GetProperty(propertyName);

            

            if (prop != null)
            {
                try
                {
                    Type propertyType = Type.GetType(prop.PropertyType.FullName + ", " +
                                                     prop.PropertyType.FullName.Split('.')[0] + "." +
                                                     prop.PropertyType.FullName.Split('.')[1]);

                    if (string.IsNullOrEmpty(direction) || direction.ToLower() == "descending")
                        AllObjects = new ObservableCollection<T>(AllObjects.OrderByDescending(x => prop.GetValue(x, null)).ToList());
                    else
                    {

                       // var list = AllObjects.OrderBy(x => Convert.ChangeType(prop.GetValue(x, null), propertyType));

                        //var list = AllObjects.OrderBy(x => (propertyType) prop.GetValue(x, null));

                     //   var list2 = AllObjects.OrderBy(x => prop.GetValue(x, null)).ToList();
                        AllObjects = new ObservableCollection<T>(AllObjects.OrderBy(x => prop.GetValue(x, null)).ToList());
                    }

                    CurrentPageNumber = 1;
                    SetCurrentPageItems();
                }
                catch (Exception e)
                {
                    Logger.Log.Error("Error en el ordenamiento: " + e.Message);
             
                }
                
              
            }
        }
    }
}
