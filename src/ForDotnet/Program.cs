// See https://aka.ms/new-console-template for more information

using System;
using ForDotnet;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

var yml = @"
name: George Washington
age: 89
height_in_inches: 5.75
addresses:
  home:
    street: 400 Mockingbird Lane
    city: Louaryland
    state: Hawidaho
    zip: 99970
  work:
    street: 1600 Pennsylvania Avenue NW
    city: Washington
    state: District of Columbia
    zip: 20500
addr:
  home:
    street: 123 Mockingbird Lane
    city: Louaryland
    state: Hawidaho
    zip: 99970
  work:
    street: 1600 Pennsylvania Avenue NW
    city: Washington
    state: District of Columbia
    zip: 20500
";

var converter = new Converter();
var deserializerBuilder = new DeserializerBuilder()
  .WithNamingConvention(UnderscoredNamingConvention.Instance)
  .WithTypeConverter(converter);

converter.ValueDeserializer = deserializerBuilder.BuildValueDeserializer();

//yml contains a string containing your YAML
var p = deserializerBuilder.Build().Deserialize<Person>(yml);
var h = p.Addresses["home"];

Console.WriteLine($"{p.Name} is {p.Age} years old and lives at {h.Street} in {h.City}, {h.State}.");

foreach (var address2 in p.Addr)
{ 
  Console.WriteLine(address2.ToString());
}
