namespace Colab.Common.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Reflection;

    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Convert our Enumeration to a DataSet
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns>DataSet</returns>
        public static DataSet ToDataSet<T>(this IEnumerable<T> list)
        {
            Type elementType = typeof(T);
            using (DataSet ds = new DataSet())
            {
                using (DataTable t = new DataTable())
                {
                    ds.Tables.Add(t);

                    // add a column to table for each public property on T
                    PropertyInfo[] props = elementType.GetProperties();
                    foreach (PropertyInfo propInfo in props)
                    {
                        Type pi = propInfo.PropertyType;
                        Type colType = Nullable.GetUnderlyingType(pi) ?? pi;
                        t.Columns.Add(propInfo.Name, colType);
                    }

                    // go through each property on T and add each value to the table
                    foreach (T item in list)
                    {
                        DataRow row = t.NewRow();
                        foreach (PropertyInfo propInfo in props)
                        {
                            row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value;
                        }

                        t.Rows.Add(row);
                    }
                }

                return ds;
            }
        }

        public static DataTable ToDataTable<T>(this IEnumerable<T> data)
        {
            var properties = TypeDescriptor.GetProperties(typeof(T));
            var outputTable = new DataTable();

            for (int i = 0; i < properties.Count; i++)
            {
                var property = properties[i];
                if (string.IsNullOrWhiteSpace(property.Description))
                {
                    outputTable.Columns.Add(property.Name, property.PropertyType);
                }
                else
                {
                    outputTable.Columns.Add(property.Description, property.PropertyType);
                }
            }

            var values = new object[properties.Count];
            foreach (var item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = properties[i].GetValue(item);
                }

                outputTable.Rows.Add(values);
            }

            return outputTable;
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
            }
        }
    }
}
