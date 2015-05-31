/*
 * Hawkmatix Moving Median 1.0.0.1
 * Official project page: http://www.hawkmatix.com/moving-median.html
 *
 * Copyright (C) 2012, 2013 Andrew Hawkins
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

// Using declarations
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml.Serialization;
using NinjaTrader.Cbi;
using NinjaTrader.Data;
using NinjaTrader.Gui.Chart;

// Begin indicator script
namespace NinjaTrader.Indicator
{
	// Description
	[Description("Hawkmatix Moving Median is the exact median of price over a period.")]

	// Begin class script
	public class HawkmatixMovingMedian : Indicator
	{
		// Declare class variables
		private int period = 34;
		private double[] data;

		// Override Initialize method
		protected override void Initialize()
		{
			// Add plots
			Add(new Plot(new Pen(Color.Blue, 3), PlotStyle.Line, "Median"));

			// Default parameters
			CalculateOnBarClose = false;
			MaximumBarsLookBack = MaximumBarsLookBack.Infinite;
			Overlay             = true;

			// Array to hold price values
			data = new double[period];
		}

		// Override OnBarUpdate method
		protected override void OnBarUpdate()
		{
			// Protect against too few bars.
			if (CurrentBar < period)
			{
				Value.Reset();
				return;
			}

			// Get the close data into an array
			for (int i = 0; i < period; i++)
			{
				data[i] = Close[i];
			}

			// Sort the array
			Array.Sort(data);

			// Determine median by filtering period
			if (period % 2 == 0)
			{
				int index = period / 2;
				Value.Set((data[index - 1] + data[index]) / 2);
			}
			else
			{
				int index = (period - 1) / 2;
				Value.Set(data[index]);
			}
		}

		// Properties of plots and inputs
		[Browsable(false)]
		[XmlIgnore()]
		public DataSeries Value
		{
			get { return Values[0]; }
		}

		[Description("Amount of bars used for calculations.")]
		[GridCategory("Parameters")]
		public int Period
		{
			get { return period; }
			set { period = Math.Max(1, value); }
		}
	}
}
