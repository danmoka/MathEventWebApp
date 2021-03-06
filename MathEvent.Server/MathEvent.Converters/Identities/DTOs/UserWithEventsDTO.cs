﻿using MathEvent.Converters.Events.DTOs;
using MathEvent.Converters.Organizations.DTOs;
using System.Collections.Generic;

namespace MathEvent.Converters.Identities.DTOs
{
    /// <summary>
    /// Transfer объект сущности пользователя с событиями
    /// </summary>
    public class UserWithEventsDTO
    {
        public UserWithEventsDTO()
        {
            Events = new HashSet<EventDTO>();
            ManagedEvents = new HashSet<EventDTO>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public OrganizationDTO Organization { get; set; }

        public virtual ICollection<EventDTO> Events { get; set; }

        public virtual ICollection<EventDTO> ManagedEvents { get; set; }
    }
}
