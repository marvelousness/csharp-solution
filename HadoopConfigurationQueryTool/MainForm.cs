using HadoopConfigurationQueryTool.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.ListView;
using static System.Windows.Forms.ListViewItem;

namespace HadoopConfigurationQueryTool
{
    public partial class MainForm : Form
    {
        private readonly string[] groups = { "core", "hdfs", "mapred", "yarn" };
        private readonly DataSet set = new DataSet();
        public MainForm()
        {
            InitializeComponent();

            this.lblValue.Text = "";
            this.txtDescription.Text = "";

            foreach (string group in groups)
            {
                string xml = Resources.ResourceManager.GetString(group + "_default");
                XmlDocument document = new XmlDocument();
                document.LoadXml(xml);
                XmlNodeList nodes = document.SelectNodes("configuration/property");
                if (nodes == null || nodes.Count < 1) 
                {
                    continue;
                }
                TreeNode tnode = new TreeNode(group + "-site.xml");
                DataTable table = new DataTable(tnode.Text);
                // 设计表格的列
                {
                    table.Columns.Add("name", Type.GetType("System.String"));
                    table.Columns.Add("value", Type.GetType("System.String"));
                    table.Columns.Add("description", Type.GetType("System.String"));
                }
                foreach (XmlNode xmlnode in nodes)
                {
                    XmlNode namenode = xmlnode.SelectSingleNode("name");
                    if (namenode == null || string.IsNullOrEmpty(namenode.InnerText)) 
                    {
                        continue;
                    }
                    XmlNode valuenode = xmlnode.SelectSingleNode("value");
                    XmlNode descriptionnode = xmlnode.SelectSingleNode("description");
                    string name = namenode.InnerText;
                    string value = valuenode != null ? valuenode.InnerText : "";
                    string description = descriptionnode != null ? descriptionnode.InnerText : "";

                    DataRow row = table.NewRow();
                    row["name"] = name;
                    row["value"] = value;
                    row["description"] = description;
                    table.Rows.Add(row);

                    tnode.Nodes.Add(new TreeNode(name));
                }
                this.set.Tables.Add(table);
                this.tv.Nodes.Add(tnode);
            }
        }

        private ListViewItem[] getCollection(XmlDocument document) 
        {
            ListViewItem[] items = null;
            
            return items;
        }

        private void tv_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == null || e.Node.Parent == null) 
            {
                return;
            }
            string name = e.Node.Text;
            string tname = e.Node.Parent.Text;
            DataTable table = this.set.Tables[tname];
            if (table == null) 
            {
                return;
            }
            DataRow[] rows = table.Select("name='" + name + "'");
            
        }
    }
}
