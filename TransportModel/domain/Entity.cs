using System;

namespace TransportModel.domain
{
    [Serializable]
    public class Entity<ID>
    {
        private const long serialVersionUID = 733112453532525L;

        private ID id;

        public ID GetId()
        { return id; }

        public void SetId(ID value)
        { id = value; }
    }
}
