# clean-architecture

In Clean Architecture the application is divided into horizontal layers. This allows to easy switch out e.g. the UI or the database.
In Vertical Slice Architecture the application is divided into vertical slices. This allows to easy switch out an entire use case or add a new use case without changing any existing use case.

In the Clean Architecture book Robert Martin points out that the uses cases should be sliced vertical while in Vertical Slice Architecture it is the entire application.
In Vertical Slice Architecture changing e.g. the UI might be difficault as you need to go through each use case and switch the UI part. Also if the framework change it will require extra work to extract the application and business logic.

In my example I have tried to take the best from both architectures. So I have kept the horizontal layers from Clean Architecture but each layer is sliced by the use cases. 
Compared to Vertical Slice Architecture this gives a bit more work but not much and at the same time it gives the benefits from Clean Architecture.

# MediatR

In all examples I have found MediatR is used. This is fine as it works very well, but I have tried to decouple it i bit more so that the actual implementation of the use cases does not have a direct dependency on MediatR but instead depends on my own abstractions.
In case I for some reason want to replace MediatR I only have to replace it is a few files instead of going throuh all use cases.


