using System;
using System.Collections.Generic;
using ISEN.BBC.Library.Models;
using ISEN.BBC.Library.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace ISEN.BBC.Library.Data
{
    public class SeedData
    {
        private readonly ApplicationDbContext _context;
        private readonly IVoyageRepository _voyageRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly ILogger<SeedData> _logger;

        public SeedData(
            ApplicationDbContext context,
            ILogger<SeedData> logger, 
            IVoyageRepository voyageRepository, 
            IReservationRepository reservationRepository)
        {
            _context = context;
            _logger = logger;
            _voyageRepository = voyageRepository;
            _reservationRepository = reservationRepository;
        }

        public void AddVoyageReservation()
        {
            var v1 = new Voyage
            {
                Date = DateTime.Parse("2017-05-22 17:30"),
                Depart = "Saint Raphael",
                Destination = "Mougins",
                Places = 4,
                IsArchived = true,
                Comment = "Go to Mougins",
                Name = "Bob"
            };
            var v2 = new Voyage
            {
                Date = DateTime.Parse("2017-05-23 17:00"),
                Depart = "Saint Raphael",
                Destination = "Mougins",
                Places = 4,
                IsArchived = true,
                Comment = "Go to Mougins",
                Name = "Jean"
            };
            var v3 = new Voyage
            {
                Date = DateTime.Parse("2017-06-01 17:30"),
                Depart = "Saint Raphael",
                Destination = "Mougins",
                Places = 3,
                IsArchived = false,
                Comment = "Go to Mougins",
                Name = "Tom"
            };
            var v4 = new Voyage
            {
                Date = DateTime.Parse("2017-06-08 16:00"),
                Depart = "Saint Raphael",
                Destination = "Mougins",
                Places = 2,
                IsArchived = false,
                Comment = "Go to Mougins",
                Name = "Franck"
            };
            var v5 = new Voyage
            {
                Date = DateTime.Parse("2017-06-12 16:00"),
                Depart = "Saint Raphael",
                Destination = "Mougins",
                Places = 4,
                IsArchived = false,
                Comment = "Go to Mougins",
                Name = "Robert"
            };
            var v6 = new Voyage
            {
                Date = DateTime.Parse("2017-06-01 16:00"),
                Depart = "Toulon",
                Destination = "Saint Raphael",
                Places = 4,
                IsArchived = false,
                Comment = "Back to home",
                Name = "Gégé"
            };
            var v7 = new Voyage
            {
                Date = DateTime.Parse("2017-06-12 16:00"),
                Depart = "Saint Raphael",
                Destination = "Toulon",
                Places = 4,
                IsArchived = false,
                Comment = "Go to Toulon",
                Name = "Timmy"
            };
            var v8 = new Voyage
            {
                Date = DateTime.Parse("2017-06-12 16:00"),
                Depart = "Paris",
                Destination = "Nice",
                Places = 4,
                IsArchived = false,
                Comment = "Back to home",
                Name = "Jack"
            };
            var v9 = new Voyage
            {
                Date = DateTime.Parse("2017-05-22 17:30"),
                Depart = "Saint Raphael",
                Destination = "Mougins",
                Places = 4,
                IsArchived = true,
                Comment = "Go to Mougins",
                Name = "Yan"
            };
            var v10 = new Voyage
            {
                Date = DateTime.Parse("2017-05-23 17:00"),
                Depart = "Saint Raphael",
                Destination = "Mougins",
                Places = 4,
                IsArchived = true,
                Comment = "Go to Mougins",
                Name = "Micheal"
            };
            var v11 = new Voyage
            {
                Date = DateTime.Parse("2017-06-01 17:30"),
                Depart = "Saint Raphael",
                Destination = "Mougins",
                Places = 3,
                IsArchived = false,
                Comment = "Go to Mougins",
                Name = "Jacky"
            };
            var v12 = new Voyage
            {
                Date = DateTime.Parse("2017-06-08 16:00"),
                Depart = "Toulon",
                Destination = "Mougins",
                Places = 4,
                IsArchived = false,
                Comment = "Go to Mougins",
                Name = "Milton"
            };
            var v13 = new Voyage
            {
                Date = DateTime.Parse("2017-06-12 16:00"),
                Depart = "Saint Raphael",
                Destination = "Mougins",
                Places = 4,
                IsArchived = false,
                Comment = "Go to Mougins",
                Name = "Francois"
            };
            var v14 = new Voyage
            {
                Date = DateTime.Parse("2017-06-01 16:00"),
                Depart = "Toulon",
                Destination = "Saint Raphael",
                Places = 4,
                IsArchived = false,
                Comment = "Back to home",
                Name = "Martin"
            };
            var v15 = new Voyage
            {
                Date = DateTime.Parse("2017-06-12 16:00"),
                Depart = "Saint Raphael",
                Destination = "Toulon",
                Places = 2,
                IsArchived = false,
                Comment = "Go to Toulon",
                Name = "Martine"
            };
            var v16 = new Voyage
            {
                Date = DateTime.Parse("2017-06-12 16:00"),
                Depart = "Nice",
                Destination = "Saint Raphael",
                Places = 1,
                IsArchived = false,
                Comment = "Back to home",
                Name = "Babe"
            };

            _voyageRepository.UpdateRange(v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16);
            _voyageRepository.Save();

            var r1 = new Reservation {Comment = "Véronique a réservé", Voyage = v1, Name = "Véronique" };
            var r2 = new Reservation {Comment = "Alexandre a réservé", Voyage = v3, Name = "Jeanine" };
            var r3 = new Reservation {Comment = "Olivier a réservé", Voyage = v3, Name = "Brigitte" };
            var r4 = new Reservation {Comment = "Didier a réservé", Voyage = v3, Name = "Sarah" };
            var r5 = new Reservation {Comment = "Brigitte a réservé", Voyage = v4, Name = "Brigitte" };
            var r6 = new Reservation {Comment = "Huguette a réservé", Voyage = v6, Name = "Huguette" };
            var r7 = new Reservation {Comment = "Jean-Charles a réservé", Voyage = v7, Name = "Jean-Charles" };
            var r8 = new Reservation {Comment = "Gaudefroit a réservé", Voyage = v8, Name = "Gaudefroit" };
            var r9 = new Reservation {Comment = "Obelix a réservé", Voyage = v9, Name = "Obelix" };
            var r10 = new Reservation {Comment = "John a réservé", Voyage = v16, Name = "John" };

            _reservationRepository.UpdateRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10);
            _reservationRepository.Save();
        }

        public void DropCreateDatabase()
        {
            var deleted = _context.Database.EnsureDeleted();
            var deletedString = deleted ? "dropped" : "not dropped";
            _logger.LogWarning($"Database was {deletedString}");

            var created = _context.Database.EnsureCreated();
            var createdString = deleted ? "created" : "not created";
            _logger.LogWarning($"Database was {createdString}");
        }
    }
}