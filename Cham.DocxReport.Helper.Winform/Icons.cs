using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Cham.DocxReport.Helper.Core;

namespace Cham.DocxReport.Helper.Winform
{
    public static class Icons
    {
        private static ImageList m_imageList;
        public static ImageList ImageList
        {
            get
            {
                if (m_imageList == null)
                {
                    m_imageList = new ImageList();
                    m_imageList.ColorDepth = ColorDepth.Depth32Bit;
                    refreshImageList();
                }

                return m_imageList;
            }
        }

        private static Dictionary<eIcon, Image> m_icons;
        public static Dictionary<eIcon, Image> IconsDico
        {
            get
            {
                if (m_icons == null)
                {
                    m_icons = new Dictionary<eIcon, Image>();

                    //m_icons.Add(eIcon.IconeVide, Images.Icon.Icons.EmptyIcon);
                    m_icons.Add(eIcon.Database, IconsResource.Database);
                    m_icons.Add(eIcon.Maintenance, IconsResource.Maintenance.ToBitmap());
                    m_icons.Add(eIcon.Column, IconsResource.Column.ToBitmap());

                }
                return m_icons;
            }
        }

        private static void refreshImageList()
        {
            m_imageList.Images.Clear();
            foreach (int key in IconsDico.Keys)
            {
                m_imageList.Images.Add(key.ToString(), IconsDico[(eIcon)key]);
            }
        }
    }

    
}
