Hello-Agatha
============

Experimenting with the Agatha rrsl

* Added generic message handler that extends the base handler to get strongly typed responses

* InvalidatingCacheManager.cs is an experimental mechanism for cache invalidation
  - Allows request types to specify whether the response can be returned from the cache or if we should request 
    a fresh response object
  - Seems to be working for both CLIENT and SERVER side caching :)

* Added Agatha.Web to experiment with dynamically loading user controls using an MVP pattern
  - Talks to a new Agatha handler (WelcomeMessageHandler) to prove we can talk to services from our presenter 
  - TODO: find a cleaner way to resolve dependencies in the control and the presenter

