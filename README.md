# Cargo Booking Kata

## Expressing the domain

### Part 1 - Book cargos
- Application must be able to book cargos on vessels.
- Each booking much have a booking confirmation number.
- Cargos must to be added to Vessels in order to be transported.
- Vessel capacity is measured in cubic feet.
- Cargo should have size measured in cubic feet.
- Vessel should not accept cargos if there is no capacity.
- Application should inform when vessel has no capacity to carry the cargo.
- Cubic feet cannot be negative.

NOTE:
- For this example, we will just focus on the domain classes.
- UI and persistence are out of scope.

### Part 2 - Overbooking police
- Due to cargos not arriving on time at the port, business decided to introduce an overbooking policy
- Application should allow cargos to be book up to 110% of vessel's maximum capacity.