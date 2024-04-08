//-----------------------------------------------------------------------------
// <auto-generated>
//     This file was generated by the C# SDK Code Generator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//-----------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using UnityEngine.Scripting;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Unity.Services.CloudSave.Internal.Http;



namespace Unity.Services.CloudSave.Internal.Models
{
    /// <summary>
    /// FileItem model
    /// </summary>
    [Preserve]
    [DataContract(Name = "file-item")]
    internal class FileItem
    {
        /// <summary>
        /// Creates an instance of FileItem.
        /// </summary>
        /// <param name="size">size param</param>
        /// <param name="modified">modified param</param>
        /// <param name="created">created param</param>
        /// <param name="writeLock">writeLock param</param>
        /// <param name="contentType">contentType param</param>
        /// <param name="filename">filename param</param>
        [Preserve]
        public FileItem(string size, ModifiedMetadata modified, ModifiedMetadata created, string writeLock, string contentType, string filename = default)
        {
            Size = size;
            Modified = modified;
            Created = created;
            WriteLock = writeLock;
            ContentType = contentType;
            Filename = filename;
        }

        /// <summary>
        /// 
        /// </summary>
        [Preserve]
        [DataMember(Name = "size", IsRequired = true, EmitDefaultValue = true)]
        public string Size{ get; }
        /// <summary>
        /// 
        /// </summary>
        [Preserve]
        [DataMember(Name = "modified", IsRequired = true, EmitDefaultValue = true)]
        public ModifiedMetadata Modified{ get; }
        /// <summary>
        /// 
        /// </summary>
        [Preserve]
        [DataMember(Name = "created", IsRequired = true, EmitDefaultValue = true)]
        public ModifiedMetadata Created{ get; }
        /// <summary>
        /// 
        /// </summary>
        [Preserve]
        [DataMember(Name = "writeLock", IsRequired = true, EmitDefaultValue = true)]
        public string WriteLock{ get; }
        /// <summary>
        /// 
        /// </summary>
        [Preserve]
        [DataMember(Name = "contentType", IsRequired = true, EmitDefaultValue = true)]
        public string ContentType{ get; }
        /// <summary>
        /// 
        /// </summary>
        [Preserve]
        [DataMember(Name = "filename", EmitDefaultValue = false)]
        public string Filename{ get; }
    
    }
}

