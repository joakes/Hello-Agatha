Hello-Agatha
============

Experimenting with the Agatha rrsl

* Added generic message handler that extends the base handler to get strongly typed responses

* InvalidatingCacheManager.cs is an experimental mechanism for cache invalidation
  - Allows request types to specify whether the response can be returned from the cache or if we should request 
    a fresh response object
  - Seems to be working for both CLIENT and SERVER side caching :)
