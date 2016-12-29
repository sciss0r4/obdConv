using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ODXConverter
{
    public class NodeSorter : IComparer
    {
        //nie wiem czemu to działa ale tak jest. 
        public int Compare(object x, object y)
        {
            TreeNode tx = (TreeNode)x;
            TreeNode ty = (TreeNode)y;
            if (tx.Parent != null && tx.Parent == ty.Parent)
            {
                return Comparer<string>.Default.Compare(tx.Name, ty.Name);
            }
            return 0;
        }
    }
}
