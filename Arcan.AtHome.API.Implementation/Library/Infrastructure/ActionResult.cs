using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Arcan.AtHome.API.Implementation.Infrastructure
{
    public class ActionResult
    {
        public ActionResult()
        {
            this.Messages = new Message[0];
        }

        public ActionResult(bool succeeded)
        {
            Succeeded = succeeded;
            this.Messages = new Message[0];
        }

        public ActionResult(bool succeeded, IEnumerable<Message> messages)
        {
            Succeeded = succeeded;
            Messages = messages != null ? messages.ToArray() : new Message[0];
        }

        public ActionResult(bool succeeded, params Message[] messages)
        {
            Succeeded = succeeded;
            Messages = messages;
        }

        public bool Succeeded { get; set; }

        public Message[] Messages { get; protected set; }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, (object[])this.Messages);
        }
    }

    public class ActionResult<T> : ActionResult
    {
        public ActionResult()
        {

        }

        public ActionResult(bool succeeded, T entity)
        {
            Succeeded = succeeded;
            Entity = entity;
        }

        public ActionResult(bool succeeded, T entity, IEnumerable<Message> messages)
        {
            Succeeded = succeeded;
            Entity = entity;
            Messages = messages != null ? messages.ToArray() : new Message[0];
        }

        public ActionResult(bool succeeded, T entity, params Message[] messages)
        {
            Succeeded = succeeded;
            Entity = entity;
            Messages = messages;
        }

        private T _entity;
        public T Entity
        {
            get
            {
                if (EqualityComparer<T>.Default.Equals(_entity, default(T)) == false)
                    return _entity;
                if (this.GetEntity != null)
                    _entity = this.GetEntity();
                return _entity;
            }
            set
            {
                this._entity = value;
            }
        }

        /// <summary>
        /// Dans le cas ou l'entity de retour a son ID généré en base, il faut faire un savechanges pour récupérer cet ID.
        /// Afin de respecter notre architecture, les savechanegs sont chassés des commandes
        /// On utilise cette fonction pour pointer vers le résultat à retourner
        /// </summary>
        [JsonIgnore]
        public Func<T> GetEntity { private get; set; }
    }
}