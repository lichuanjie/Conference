﻿using ENode.Commanding;
using Registration.Commands;

namespace Registration.CommandHandlers
{
    public class SeatAssignmentsHandler :
        ICommandHandler<CreateSeatAssignments>,
        ICommandHandler<UnassignSeat>,
        ICommandHandler<AssignSeat>
    {
        public void Handle(ICommandContext context, CreateSeatAssignments command)
        {
            context.Add(context.Get<Order>(command.AggregateRootId).CreateSeatAssignments());
        }
        public void Handle(ICommandContext context, AssignSeat command)
        {
            context.Get<SeatAssignments>(command.AggregateRootId).AssignSeat(command.Position, command.Attendee);
        }
        public void Handle(ICommandContext context, UnassignSeat command)
        {
            context.Get<SeatAssignments>(command.AggregateRootId).Unassign(command.Position);
        }
    }
}
