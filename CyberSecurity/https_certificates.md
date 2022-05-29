# Developer certificates for HTTPS with Rider

* Run command prompt
* Clean oldest certificates ``dotnet dev-certs https --clean``
* Assert all certificates have been deleted ``dotnet dev-certs https --check --verbose``
* Create new developer certificate ``dotnet dev-certs https --trust``
* Check if certificate have been created ``dotnet dev-certs https --check --verbose``