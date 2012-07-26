﻿// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System.ComponentModel;
using Microsoft.Windows.Controls.Design.Common;
using Microsoft.Windows.Design.Metadata;

namespace Microsoft.Windows.Controls.Theming.Design
{
    /// <summary>
    /// To register design time metadata for Theme.
    /// </summary>
    internal class ThemeMetadata : AttributeTableBuilder
    {
        /// <summary>
        /// To register design time metadata for Theme.
        /// </summary>
        public ThemeMetadata()
            : base()
        {
            AddCallback(
                typeof(Theme),
                b =>
                {
                    b.AddCustomAttributes(Extensions.GetMemberName<Theme>(x => x.ApplyMode), new CategoryAttribute(Properties.Resources.CommonProperties));
                });
        }
    }
}
