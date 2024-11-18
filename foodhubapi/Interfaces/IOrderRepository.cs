using System;
using foodhubapi.Models;

namespace foodhubapi.Interfaces;

public interface IOrderRepository
{
  Task<Order> CreateAsync();
}
