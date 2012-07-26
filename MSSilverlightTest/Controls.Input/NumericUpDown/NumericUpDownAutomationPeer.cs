﻿// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;

[assembly: SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "Microsoft.Windows.Controls.Automation.Peers.NumericUpDownAutomationPeer.#System.Windows.Automation.Provider.IRangeValueProvider.IsReadOnly", Justification = "Follow the convention of RangeBase in WPF & Silverlight.")]
[assembly: SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "Microsoft.Windows.Controls.Automation.Peers.NumericUpDownAutomationPeer.#System.Windows.Automation.Provider.IRangeValueProvider.LargeChange", Justification = "Follow the convention of RangeBase in WPF & Silverlight.")]
[assembly: SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "Microsoft.Windows.Controls.Automation.Peers.NumericUpDownAutomationPeer.#System.Windows.Automation.Provider.IRangeValueProvider.Maximum", Justification = "Follow the convention of RangeBase in WPF & Silverlight.")]
[assembly: SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "Microsoft.Windows.Controls.Automation.Peers.NumericUpDownAutomationPeer.#System.Windows.Automation.Provider.IRangeValueProvider.Minimum", Justification = "Follow the convention of RangeBase in WPF & Silverlight.")]
[assembly: SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "Microsoft.Windows.Controls.Automation.Peers.NumericUpDownAutomationPeer.#System.Windows.Automation.Provider.IRangeValueProvider.SmallChange", Justification = "Follow the convention of RangeBase in WPF & Silverlight.")]
[assembly: SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "Microsoft.Windows.Controls.Automation.Peers.NumericUpDownAutomationPeer.#System.Windows.Automation.Provider.IRangeValueProvider.Value", Justification = "Follow the convention of RangeBase in WPF & Silverlight.")]

namespace Microsoft.Windows.Controls.Automation.Peers
{
    /// <summary>
    /// Exposes NumericUpDown types to UI Automation.
    /// </summary>
    /// <QualityBand>Preview</QualityBand>
    public partial class NumericUpDownAutomationPeer
        : UpDownBaseAutomationPeer<double>, IRangeValueProvider
    {
        /// <summary>
        /// Initializes a new instance of the NumericUpDownAutomationPeer class.
        /// </summary>
        /// <param name="owner">
        /// The NumericUpDown that is associated with this NumericUpDownAutomationPeer.
        /// </param>
        public NumericUpDownAutomationPeer(NumericUpDown owner)
            : base(owner)
        {
        }

        #region AutomationPeer Overrides
        /// <summary>
        /// Gets the name of the NumericUpDown that is associated with this
        /// NumericUpDownAutomationPeer.  This method is called by GetClassName.
        /// </summary>
        /// <returns>The name NumericUpDown.</returns>
        protected override string GetClassNameCore()
        {
            return "NumericUpDown";
        }

        /// <summary>
        /// Gets the control pattern for the NumericUpDown that is associated
        /// with this NumericUpDownAutomationPeer.
        /// </summary>
        /// <param name="patternInterface">The desired PatternInterface.</param>
        /// <returns>The desired AutomationPeer or null.</returns>
        public override object GetPattern(PatternInterface patternInterface)
        {
            if (patternInterface == PatternInterface.RangeValue)
            {
                return this;
            }

            return base.GetPattern(patternInterface);
        }
        #endregion

        #region Implement IRangeValueProvider
        /// <summary>
        /// Sets the value of the NumericUpDown.
        /// </summary>
        /// <param name="value">The value to set.</param>
        /// <remarks>
        /// This API supports the .NET Framework infrastructure and is not 
        /// intended to be used directly from your code.
        /// </remarks>
        void IRangeValueProvider.SetValue(double value)
        {
            if (!IsEnabled())
            {
                throw new ElementNotEnabledException();
            }

            NumericUpDown owner = (NumericUpDown)Owner;

            // Note: copied below value check from WPF & SL implementation.
            // It is probably for avoiding triggering coercion. 
            if (value < owner.Minimum || value > owner.Maximum)
            {
                throw new ArgumentOutOfRangeException("value");
            }
            owner.Value = value;
        }

        /// <summary>
        /// Gets a value indicating whether the value of the NumericUpDown is read-only.
        /// </summary>
        /// <remarks>
        /// This API supports the .NET Framework infrastructure and is not 
        /// intended to be used directly from your code.
        /// </remarks>
        bool IRangeValueProvider.IsReadOnly
        {
            get
            {
                return !IsEnabled();
            }
        }

        /// <summary>
        /// Gets the value to be added or subtracted from the Value property of the NumericUpDown.
        /// </summary>
        /// <remarks>
        /// This API supports the .NET Framework infrastructure and is not 
        /// intended to be used directly from your code.
        /// </remarks>
        double IRangeValueProvider.LargeChange
        {
            get
            {
                return ((NumericUpDown)Owner).Increment;
            }
        }

        /// <summary>
        /// Gets the maximum value supported by the NumericUpDown.
        /// </summary>
        /// <remarks>
        /// This API supports the .NET Framework infrastructure and is not 
        /// intended to be used directly from your code.
        /// </remarks>
        double IRangeValueProvider.Maximum
        {
            get
            {
                return ((NumericUpDown)Owner).Maximum;
            }
        }

        /// <summary>
        /// Gets minimum value supported by the NumericUpDown.
        /// </summary>
        /// <remarks>
        /// This API supports the .NET Framework infrastructure and is not 
        /// intended to be used directly from your code.
        /// </remarks>
        double IRangeValueProvider.Minimum
        {
            get
            {
                return ((NumericUpDown)Owner).Minimum;
            }
        }

        /// <summary>
        /// Gets the value to be added or subtracted from the Value property of the NumericUpDown.
        /// </summary>
        /// <remarks>
        /// This API supports the .NET Framework infrastructure and is not 
        /// intended to be used directly from your code.
        /// </remarks>
        double IRangeValueProvider.SmallChange
        {
            get
            {
                return ((NumericUpDown)Owner).Increment;
            }
        }

        /// <summary>
        /// Gets the value of the NumericUpDown.
        /// </summary>
        /// <remarks>
        /// This API supports the .NET Framework infrastructure and is not 
        /// intended to be used directly from your code.
        /// </remarks>
        double IRangeValueProvider.Value
        {
            get
            {
                return ((NumericUpDown)Owner).Value;
            }
        }
        #endregion
    }
}
