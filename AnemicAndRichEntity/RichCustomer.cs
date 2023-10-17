namespace AnemicAndRichEntity
{
    public sealed class RichCustomer
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }

        public RichCustomer(int id, string name, string address)
        {
            ValidateAndThrow(id, name, address);

            Id = id;
            Name = name;
            Address = address;
        }

        public void Update(int id, string name, string address)
        {
            ValidateAndThrow(id, name, address);

            Id = id;
            Name = name;
            Address = address;
        }

        private static void ValidateAndThrow(int id, string name, string address)
        {
            if (id < 0)
            {
                throw new ArgumentException("Identifier must be greater than 0");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name cannot be empty");
            }

            if (string.IsNullOrEmpty(address))
            {
                throw new ArgumentException("Address cannot be empty");
            }

            if (name.Length < 3)
            {
                throw new ArgumentException("Name must be have more than 3 characters");
            }

            if (name.Length > 100)
            {
                throw new ArgumentException("Name cannot be have more than 100 characters");
            }
        }
    }
}
