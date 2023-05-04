using System;

namespace TransportClientFX
{
    public enum UserEvent
    {
        RezervareReceived
    }
    public class UserEventArgs : EventArgs
    {
        private readonly UserEvent userEvent;
        private readonly Object data;

        public UserEventArgs(UserEvent userEvent, object data)
        {
            this.userEvent = userEvent;
            this.data = data;
        }

        public Object Data
        {
            get { return data; }
        }

        public UserEvent UserEventType
        {
            get { return userEvent; }
        }
    }
}