using System;
using System.Data;
using System.Text.RegularExpressions;

namespace Cham.DocxReport
{
    /// <summary>
    /// Classe réprésentant le champ de fusion.
    /// </summary>
    internal class FieldParameter
    {
        #region Properties

        internal int FieldLocation
        {
            get;
            set;
        }

        internal string TableName
        {
            get;
            set;
        }

        internal string ColumnName
        {
            get;
            set;
        }

        internal string Format
        {
            get;
            set;
        }

        internal string Text
        {
            get;
            set;
        }

        internal DataRelation DataRelation
        {
            get;
            set;
        }

        internal Container ParentContainer
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public override bool Equals(object obj)
        {
            if (obj.GetType() == GetType())
            {
                FieldParameter obj2 = obj as FieldParameter;
                return (obj2.ColumnName.Equals(this.ColumnName) && obj2.TableName.Equals(this.TableName));
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (ColumnName + TableName).GetHashCode();
        }

        internal string GetValue(DataRow row)
        {
            try
            {
                if (row == null) return string.Empty;
                if (ColumnName.Equals(Fonctions.DocxReportOptions.EmptyMasterTableToken, StringComparison.CurrentCultureIgnoreCase)) return string.Empty;

                object o = DBNull.Value;
                if (DataRelation != null)
                {
                    if (DataRelation.ChildTable.TableName.Equals(TableName, StringComparison.CurrentCultureIgnoreCase))
                    {
                        DataRow[] rows = row.GetChildRows(DataRelation);
                        if (rows != null && rows.Length > 0)
                        {
                            o = rows[0][ColumnName];
                        }
                    }
                    else if (DataRelation.ParentTable.TableName.Equals(TableName, StringComparison.CurrentCultureIgnoreCase))
                    {
                        var parentRow = row.GetParentRow(DataRelation);
                        if (parentRow != null)
                        {
                            o = parentRow[ColumnName];
                        }
                    }
                }
                else if (row.Table.TableName.Equals(TableName))
                {
                    o = row[ColumnName];
                }
                else if (row.Table.DataSet.Tables[TableName].Rows.Count > 0)
                {
                    o = row.Table.DataSet.Tables[TableName].Rows[0][ColumnName];
                }
                string value = string.Empty;
                if (Format != string.Empty)
                {
                    var regEx = Fonctions.DocxReportOptions.BoolRegex;
                    var match = regEx.Match(Format);
                    if (match.Success)
                    {
                        value = o == DBNull.Value ? match.Groups[DocxReportOptions.NullDisplayField].Value :
                            (bool)o == true ? match.Groups[DocxReportOptions.TrueDisplayField].Value : match.Groups[DocxReportOptions.FalseDisplayField].Value;
                    }
                    else
                    {
                        value = string.Format("{0:" + Format + "}", o);
                    }
                }
                else
                {
                    value = o == DBNull.Value ? string.Empty : o.ToString();
                }
                if (string.IsNullOrEmpty(value))
                {
                    return string.Empty;
                }
                else
                {
                    Regex regEx = Fonctions.DocxReportOptions.FieldParameterRegex;
                    MatchCollection matches = regEx.Matches(value);
                    var fieldsParameters = new System.Collections.Generic.List<FieldParameter>();
                    foreach (Match match in matches)
                    {
                        GroupCollection groups = match.Groups;
                        FieldParameter field = new FieldParameter()
                        {
                            FieldLocation = match.Index,
                            ColumnName = match.Groups[DocxReportOptions.ColumnNameField].Value,
                            TableName = match.Groups[DocxReportOptions.TableNameField].Value,
                            Format = match.Groups[DocxReportOptions.FormatField].Value,
                            Text = match.ToString()
                        };

                        var rel = Container.GetDataRelation(ParentContainer.MainDataTableName, field.TableName);
                        if (rel != null)
                        {
                            field.DataRelation = rel;
                        }
                        else
                        {
                            throw new Exception(string.Format("Les colonnes ne proviennent pas de la meme table \n paragraphe: {0}.", value));
                        }

                        fieldsParameters.Add(field);
                    }
                    for (int i = 0; i < fieldsParameters.Count; i++)
                    {
                        FieldParameter field = fieldsParameters[i];
                        string newText = field.GetValue(row);
                        value = value.Replace(field.Text, newText);
                        int delta = newText.Length - field.Text.Length;
                        for (int j = 0; j < fieldsParameters.Count; j++)
                        {
                            fieldsParameters[j].FieldLocation += delta;
                        }
                    }
                }
                return value == null ? string.Empty : value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        #endregion
    }
}
