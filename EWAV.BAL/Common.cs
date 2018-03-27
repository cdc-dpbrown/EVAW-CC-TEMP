using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CDC.ISB.EIDEV.Web.EpiDashboard;

namespace CDC.ISB.EIDEV.BAL
{
    public static class Common
    {
        /// <summary>
        /// Get a List of EWAVColumns for the selected DataTable      
        /// </summary>
        /// <param name="DatasourceName"></param>
        /// <param name="Tablename"></param>
        /// <returns></returns>
        public static List<EWAVColumn> GetColumns(string DatasourceName, string Tablename)
        {
            //CommonSQLDAO commonDao = new CommonSQLDAO();
            //// Get one row to get to to the columns 
            //DataTable dt = commonDao.GetTableTopRow(DatasourceName, Tablename);
            EntityManager em = new EntityManager();

            DataTable dt = em.GetTopTwoTable(DatasourceName, Tablename);

            List<EWAVColumn> resultList = new List<EWAVColumn>();

            foreach (DataColumn dc in dt.Columns)
            {
                EWAVColumn ewavColumn = new EWAVColumn()
                {
                    Index = resultList.Count,
                    Name = dc.ColumnName,
                    SqlDataTypeAsString = GetDBType(dc.DataType)
                };

                //     System.Data.SqlDbType 
                resultList.Add(ewavColumn);
            }

            return resultList;
        }

        /// <summary>
        /// Get a List of EWAVColumns for the selected DataTable      
        /// </summary>
        /// <param name="DatasourceName"></param>
        /// <param name="Tablename"></param>k
        /// <returns></returns>
        public static List<EWAVColumn> GetColumns(DataTable dt)
        {

            List<EWAVColumn> resultList = new List<EWAVColumn>();


            foreach (DataColumn dc in dt.Columns)
            {
                EWAVColumn ewavColumn = new EWAVColumn()
                {
                    Index = resultList.Count,
                    Name = dc.ColumnName,
                    SqlDataTypeAsString = GetDBType(dc.DataType)
                };

                resultList.Add(ewavColumn);
            }

            return resultList;
        }

        //private static SqlDbType GetDBType(System.Type theType)
        //{
        //    SqlParameter p1;
        //    TypeConverter tc;
        //    p1 = new  SqlParameter();
        //    tc = TypeDescriptor.GetConverter(p1.DbType);
        //    if (tc.CanConvertFrom(theType))
        //    {
        //        p1.DbType = (DbType)tc.ConvertFrom(theType.Name);
        //    }
        //    else
        //    {
        //        //Try brute force
        //        try
        //        {
        //            if (theType.ToString().Contains("Byte"))
        //            {
        //                return SqlDbType.Bit;
        //            }
        //            p1.DbType = (DbType)tc.ConvertFrom(theType.Name);
        //        }
        //        catch (SqlException ex)
        //        {
        //            throw new Exception("Error with data table type convert. ");
        //        }
        //        catch (Exception ex)
        //        {
        //            //throw new Exception("Error with data table type convert. ");
        //        }
        //    }

        //    return p1.SqlDbType;
        //}
        public static ColumnDataType GetDBType(System.Type theType)
        {
            // todo - add ALL types  

            ColumnDataType typeToReturn = ColumnDataType.Text;
            switch (theType.ToString().ToLower())
            {
                case "system.string":
                    typeToReturn = ColumnDataType.Text;

                    break;
                case "system.byte":
                    typeToReturn = ColumnDataType.Numeric;
                    break;
                case "system.sbyte":
                    typeToReturn = ColumnDataType.Numeric;
                    break;
                case "system.int16":
                    typeToReturn = ColumnDataType.Numeric;
                    break;
                case "system.int32":
                    typeToReturn = ColumnDataType.Numeric;
                    break;
                case "system.int64":
                    typeToReturn = ColumnDataType.Numeric;
                    break;
                case "system.single":
                    typeToReturn = ColumnDataType.Numeric;
                    break;
                case "system.double":
                    typeToReturn = ColumnDataType.Numeric;
                    break;
                case "system.decimal":
                    typeToReturn = ColumnDataType.Numeric;            
                    break;

                case   "system.guid"    :
                    typeToReturn = ColumnDataType.Text;
                    break;
                 case "system.datetime":
                    typeToReturn = ColumnDataType.DateTime;
                    break;
                case "system.datetimeoffset":
                    typeToReturn = ColumnDataType.DateTime;
                    break;

                case "system.boolean":
                    typeToReturn = ColumnDataType.Boolean;
                    break;    

                case   "system.xml"    :
                    typeToReturn = ColumnDataType.Text;
                    break;    
                // This data type is not currently supported.
                case "system.object":
                    break;
                case "system.timeSpan":
                    break;
                case "system.byte[]":
                    break;
                case "system.uint64":
                    typeToReturn = ColumnDataType.Boolean;
                    break;
                default:
                    throw new Exception("Data type " + theType.ToString().ToLower() + " not supported  ");


            }

            return typeToReturn;
   
        }












    }
}