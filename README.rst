Hawkmatix Moving Median
=======================

The median of a set of values is the value directly in the middle after the
data has been arranged by its order of magnitude. The median has an advantage
over the average because it is less susceptible to being skewed by outliers, or
large changes in price. In some cases it is not optimal to assume a normal
distribution and use a moving average; instead we assume a Laplace distribution
and use the moving median. A use other than generalizing the data, is that the
moving median has shown support and resistance properties much greater than
that of the moving average. NinjaTrader's built-in median is slightly different
from the true median, so there was great need for this simple project.

Installation
------------

Install from source::

    

Package Contents
----------------

    moving-median
        Moving Median sources.

Usage
-----

This software is intended for use with the NinjaTrader trading platform.
Full documentation is available at
http://Hawkmatix.github.io/moving-median.html

Supported Operating Environment
-------------------------------

This version of the add-on software has been tested, and is known to work
against the following NinjaTrader versions and operating systems.

NinjaTrader Versions
~~~~~~~~~~~~~~~~~~~~

* NinjaTrader 7.0.1000.27
* NinjaTrader 6.5.1000.19

Operating Systems
~~~~~~~~~~~~~~~~~

* Windows 7/8

Requirements
------------

Supports NinjaTrader 6.5.1000.19 - 7.0.1000.27.

License
-------

All code contained in this repository is Copyright 2012-Present Andrew C.
Hawkins.

This code is released under the GNU Lesser General Public License. Please see
the COPYING and COPYING.LESSER files for more details.

Contributors
------------

* Andrew C. Hawkins <andrew@hawkmatix.com>

Changelog
---------

* v1 The median value over the period specified is determined.
