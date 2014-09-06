using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Cham.DocxReport.Helper.Winform.DocxFields
{
    class DataSetFusion
    {
        #region Constructor

        public DataSetFusion(DataSet ds)
        {
            BuildTables(ds);
        }

        #endregion

        #region Properties

        public List<DataTableFusion> DataTablesFusion
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }


        #endregion

        #region Methods

        private void BuildTables(DataSet ds)
        {
            Name = ds.DataSetName;
            DataTablesFusion=new List<DataTableFusion>();
            foreach (DataTable table in ds.Tables)
            {
                DataTablesFusion.Add(new DataTableFusion(table)); 
            }
        }

        #endregion
    }

    class DataTableFusion
    {
        #region Constructor

        public DataTableFusion(DataTable table)
        {
            BuildTables(table);
        }

        #endregion

        #region Properties

        public List<DataColumnFusion> DataColumnsFusion
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        public DataTable DataTable
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        private void BuildTables(DataTable table)
        {
            Name = table.TableName;
            DataColumnsFusion = new List<DataColumnFusion>();
            foreach (DataColumn column in table.Columns)
            {
                DataColumnsFusion.Add(new DataColumnFusion(column));
            }
            DataTable = table;
        }

        #endregion
    }

    class DataColumnFusion
    {
        #region Constructor

        public DataColumnFusion(DataColumn column)
        {
            Column = column;
        }

        #endregion

        #region Properties

        public DataColumn Column
        {
            get;
            private set;
        }

        public virtual string Name
        {
            get { return Column.ColumnName; }
        }

        #endregion
    }

    
}
