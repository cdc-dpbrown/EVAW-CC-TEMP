using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CDC.ISB.EIDEV.Web.Services
{
    [DataContract]
    [KnownType(typeof(EWAVRule_Recode)), 
    KnownType(typeof(EWAVRule_SimpleAssignment)),
    KnownType(typeof(EWAVRule_Format)),
    KnownType(typeof(EWAVRule_GroupVariable)),
    KnownType(typeof(EWAVRule_ExpressionAssign)),
    KnownType(typeof(EWAVRule_ConditionalAssign))]
    public class EWAVRule_Base : EntityObject
    {
        int id;

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>    
        /// 

        [Key]
        [DataMember]
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        [Key]
        [DataMember]
        public string VaraiableName
        { get; set; }

        [Key]
        [DataMember]
        public string VaraiableDataType
        { get; set; }
               
    }
    
    public enum EWAVRuleType
    {
        Recode = 0,
        Assign,
        Formatted,
        Simple,
        conditional,
        GroupVariable
    }
}