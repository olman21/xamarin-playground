using Playground.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Playground.Services
{
    public class ContactService
    {
        private List<Contact> Contacts = new List<Contact>
        {
            new Contact
            {
                Id = Guid.NewGuid(),
                Name = "Olman",
                LastName = "Mora",
                Phone = "7777-7777",
                Email = "olman@example.com"
            },
            new Contact
            {
                Id = Guid.NewGuid(),
                Name = "Roger",
                LastName = "Waters",
                Email = "roger@example.com"
            },
            new Contact
            {
                Id = Guid.NewGuid(),
                Name = "Bad",
                LastName = "Bunny",
                Email = "bad@example.com",
                Blocked = true
            }
        };

        private readonly IMapper _mapper;

        public ContactService()
        {
            var mapperConfig = new MapperConfiguration(cfg => cfg.CreateMap<Contact, Contact>());
            _mapper = new Mapper(mapperConfig);
        }

        public Task<List<Contact>> GetContacts()
        {
            return Task.FromResult(Contacts);
        }

        public Task<Contact> GetContact(Guid id)
        {
            var contact = Contacts.FirstOrDefault(e => e.Id == id);
            return Task.FromResult(contact);
        }

        public Task UpdateContact(Contact contact)
        {
            return Task.Run((() =>
            {
                var listContact = Contacts.FirstOrDefault(e => e.Id == contact.Id);
                if (listContact != null)
                {
                    listContact = _mapper.Map(contact, listContact);
                }
            }));
        }

        public Task AddContact(Contact contact)
        {
            return Task.Run((() =>
            {
                contact.Id = Guid.NewGuid();
                Contacts.Add(contact);
            }));
        }
    }
}
