using System;
using System.Collections.Generic;
using System.Linq;
using StudyAbroad.DomainModel.Framework;
using StudyAbroad.DomainModel.Exceptions;

namespace StudyAbroad.DomainModel.Core
{
    /// <summary>
    /// So the hierarchy:
    /// Universities are containedBy Cities
    /// (for US) Cities are containedBy States which are containedBy Country (USA)
    /// (for rest) Cities are contained By Countries
    /// Countries are containedBy Regions
    /// Regions are containedBy Continents
    /// Continents are containedBy the Planet
    /// </summary>
    public class Location : DataEntity
    {
        public virtual Location ContainedBy { get; protected set; }
        public virtual string Code { get; set; } 

        public Location(string inCode, string inName, Location inContainedBy) : base(inName)
        {
            ContainedBy = inContainedBy;
            Code = inCode;
        }

        public Location(string inName, Location inContainedBy) : base(inName)
        {           
            ContainedBy = inContainedBy;
        }

        public Location()
        {
        }

        public virtual bool IsCountry()
        {
            return this is Country;
        }

        public virtual bool IsState()
        {
            return this is State;
        }

        public virtual Location Self { get { return this; } }
    }
}
