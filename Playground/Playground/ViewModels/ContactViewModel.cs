using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AutoMapper;
using Playground.Extensions;
using Playground.Models;
using Playground.Services;
using Playground.SQLite;
using Xamarin.Forms;

namespace Playground.ViewModels
{
    public class ContactViewModel
    {
        public ObservableCollection<Contact> Contacts { get; set; }
        private readonly ContactService _contactService;
        public Contact CurrentContact { get; private set; }
        private readonly IMapper _mapper;
        public ICommand DeleteContactCommand { get; set; }

        public ContactViewModel(ISQLiteDb sqLiteDb)
        {
            Contacts = new ObservableCollection<Contact>();
            var mapperConfig = new MapperConfiguration(cfg => cfg.CreateMap<Contact, Contact>());
            _mapper = new Mapper(mapperConfig);
            _contactService = new ContactService(sqLiteDb);
            DeleteContactCommand = new Command<Guid>(async id => await Delete(id));
        }

        public async Task Init()
        {
            await _contactService.InitDataBase();
        }

        public async Task LoadContacts()
        {
            var list = await _contactService.GetContacts();
            Contacts.ToObservableCollection(list);
        }

        public void StartEditing(Contact contact)
        {
            CurrentContact = _mapper.Map(contact, new Contact());
        }

        public void StopEditing()
        {
            CurrentContact = null;
        }

        public IEnumerable<string> Validate()
        {
            var errors = new List<string>();
            if(string.IsNullOrEmpty(CurrentContact.FullName))
                errors.Add("First Name or LastName should be entered");
            if (string.IsNullOrEmpty(CurrentContact.Phone))
                errors.Add("Phone should be entered");

            return errors;
        }

        public async Task<IEnumerable<string>> Save()
        {
            if (CurrentContact == null) throw new ArgumentNullException(nameof(CurrentContact));

            var errors = Validate();
            if (errors.Any()) return errors;

            if (CurrentContact.Id != Guid.Empty)
            {
                await _contactService.UpdateContact(CurrentContact);
            }
            else
            {
                await _contactService.AddContact(CurrentContact);
            }

            CurrentContact = null;
            await LoadContacts();
            return errors;
        }

        public async Task Delete(Guid id)
        {
            await _contactService.DeleteContact(id);
            await LoadContacts();
        }
    }
}
