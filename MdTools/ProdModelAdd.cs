using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MdTools.Result;

namespace MdTools
{
    public partial class ProdModelAdd : Form
    {
        public ProdModelAdd()
        {
            InitializeComponent();
            GetTree();
        }


        public static List<DirItem> DirList;

        /// <summary>
        /// 获取目录树
        /// </summary>
        public void GetTree()
        {
            string m_DirUrl = Common.DirApiUrl;
            DirResult m_Result = Http.Instance.HttpGet<DirResult>(m_DirUrl, "", true);

            //List< DirItem>m_ListDirITem=m_Result.Data.ToList<DirItem>();
            //List<DirItem> m_First = m_ListDirITem.Where(m => m.pId == "0").ToList();
            DirList = m_Result.Data;

            //TreeNode m_TreeNode = new TreeNode("产品目录");

            //this.treeView1.Nodes.Add(m_TreeNode);

            SetTreeView(this.treeView1, 0);

        }
        public static  void SetTreeView(TreeView p_TreeView, int p_ParentID)
        {
            List<DirItem> m_ListItem = DirList.Where(m => m.pId == 0).ToList();
            if (m_ListItem.Count>0)
            {
                int m_Pid = -1;
                foreach (var item in m_ListItem)
                {
                    TreeNode node = new TreeNode();
                    node.Text = item.name;
                    node.Tag = item.id;
                    m_Pid = item.pId;
                    if (m_Pid==0)
                    {
                        //添加根节点
                        p_TreeView.Nodes.Add(node);
                    }
                    else
                    {
                        //添加根节点之外的其他节点
                        RefreshChildNode(p_TreeView, node, m_Pid);
                    }
                }

            }
        }

        public static void RefreshChildNode(TreeView p_TreeView, TreeNode p_node, int p_Pid)
        {
            foreach (TreeNode item in p_TreeView.Nodes)
            {
                if (item.Tag == p_Pid)
                {

                }
            }


        }




        //public static  void CreateTreeNode( List<DirItem> p_DirItemList, TreeNode p_TreeNode)
        //{
        //    TreeNode m_TreeNode = new TreeNode();

        //    List<DirItem> m_First = p_DirItemList.Where(m => m.pId == "0").ToList();

        //    for (int t_Index = 0; t_Index < m_First.Count; t_Index++)
        //    {

        //    }


        //    //p_TreeNode.Nodes.Add();

        //}











        /// <summary>
        /// 获取产品列表
        /// </summary>
        public void GetDataList()
        {

        }
    
    }
}
