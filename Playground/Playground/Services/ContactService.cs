using Playground.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Playground.SQLite;
using SQLite;

namespace Playground.Services
{
    public class ContactService
    {
        
        private readonly IMapper _mapper;
        private readonly ISQLiteDb _sqLiteDb;
        private SQLiteAsyncConnection connection => _sqLiteDb?.GetConnection();
        private AsyncTableQuery<Contact> Entities => connection.Table<Contact>();

        public ContactService(ISQLiteDb sqLiteDb)
        {
            var mapperConfig = new MapperConfiguration(cfg => cfg.CreateMap<Contact, Contact>());
            _mapper = new Mapper(mapperConfig);
            _sqLiteDb = sqLiteDb;
        }

        public Task<List<Contact>> GetContacts()
        {
            return Entities.ToListAsync();
        }

        public async Task InitDataBase()
        {
            var connection =_sqLiteDb.GetConnection();
            await connection.CreateTableAsync<Contact>();
        }

        public async Task<Contact> GetContact(Guid id)
        {
            var contact = await Entities.FirstOrDefaultAsync(e => e.Id == id);
            return contact;
        }

        public async Task UpdateContact(Contact contact)
        {
            var listContact = await Entities.FirstOrDefaultAsync(e => e.Id == contact.Id);
            if (listContact != null)
            {
                listContact = _mapper.Map(contact, listContact);
                await connection.UpdateAsync(listContact);
            }
        }

        public async Task AddContact(Contact contact)
        {
            contact.Id = Guid.NewGuid();
            await connection.InsertAsync(contact);
        }

        public async Task DeleteContact(Guid id)
        {
            var contact = await Entities.FirstOrDefaultAsync(e => e.Id == id);
            await connection.DeleteAsync(contact);
        }
    }
}
