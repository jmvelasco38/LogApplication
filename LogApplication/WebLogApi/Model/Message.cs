using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLogApi.Model
{
    /// <summary>
    /// Enumeración que contiene los tipos de mensaje que son manejados en el sistema de log
    /// </summary>
    public enum MessageType { Error = 2, Warning = 3, Message = 1 }
    /// <summary>
    /// Clase que contiene los mensaje que serán enviados a través del sistema de log
    /// </summary>
    public class Message
    {
        /// <summary>
        /// field content
        /// </summary>
        private string content;
        /// <summary>
        /// Indica el tipo de mensaje 
        /// </summary>
        public MessageType LogType { get; set; }
        /// <summary>
        /// Indica el conteni que será almacenado en el mensaje
        /// </summary>
        public string Content {
            get { return string.Format("{0}-{1}", DateTime.Now.ToShortDateString(), content); }
            set { content = value; } }

    }
    
}