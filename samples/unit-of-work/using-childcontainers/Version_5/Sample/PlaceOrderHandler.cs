﻿using System;
using NServiceBus;
using Raven.Client;

#region PlaceOrderHandler
public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
{
    IDocumentSession session;

    public PlaceOrderHandler(IDocumentSession session)
    {
        this.session = session;
    }

    public void Handle(PlaceOrder message)
    {
        Order order = new Order
        {
            OrderNumber = message.OrderNumber, 
            OrderValue = message.OrderValue
        };
        session.Store(order);

        Console.Out.WriteLine("Order {0} stored",message.OrderNumber);
    }
}
#endregion
