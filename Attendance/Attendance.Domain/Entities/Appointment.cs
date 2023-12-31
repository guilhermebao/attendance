﻿using Attendance.Domain.Entites;
using Attendance.Domain.Validation;
using System;

namespace Attendance.Domain.Entities;

public class Appointment : BaseEntity
{
    public DateTime DateTime { get; private set; }
    public string Message { get; private set; }
    public Guid CustomerId { get; private set; }

    public Customer Customer { get; set; }

    public Appointment(Guid id, DateTime dateTime, string message, Guid customerId)
    {
        ValidateDomain(dateTime, message, customerId);
        DomainExceptionValidation.When(id == Guid.Empty, "O Id do agendamento não pode ser vazio");
        Id = id;
    }

    public Appointment(DateTime dateTime, string message, Guid customerId)
    {
        ValidateDomain(dateTime, message, customerId);
    }

    public void ValidateDomain(DateTime dateTime, string message, Guid customerId)
    {
        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(message), "A mensagem do agendamento não pode estar vazia ou em branco");
        DomainExceptionValidation.When(customerId == Guid.Empty, "O Id do cliente no agendamento não pode ser vazio");

        DateTime = dateTime;
        Message = message;
        CustomerId = customerId;
    }
}
