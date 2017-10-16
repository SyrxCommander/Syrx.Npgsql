﻿//  ============================================================================================================================= 
//  author       : david sexton (@sextondjc | sextondjc.com)
//  date         : 2017.09.29 (21:39)
//  modified     : 2017.10.01 (20:40)
//  licence      : This file is subject to the terms and conditions defined in file 'LICENSE.txt', which is part of this source code package.
//  =============================================================================================================================

using System;
using System.Collections;
using System.Collections.Generic;

namespace Syrx.Tests.Models
{
    public class MultiMapPocoA
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public PocoA PocoA { get; set; }
    }


    public class Track
    {
        public string Title { get; }
        public TimeSpan Duration { get; }
    }


    public class FooFighters
    {
        public TheColourAndTheShape TheColourAndTheShape { get; }
    }

    public class TheColourAndTheShape : Album
    {
        public TheColourAndTheShape(string name, int released) : base(name, released)
        {
        }
    }

    public class Album
    {
        public string Name { get; }
        public int Released { get; }

        public Album(string name, int released)
        {
            Name = name;
            Released = released;
        }
    }
}