# ocelot-aggregation

Little exercise to work on aggregation (combine multiple routes and map the result into a single object) with ${\color{grey}Ocelot}$

At the bottom of the ocelot.json file you can find two examples of aggregation. 

<br>

```http://localhost:5206/api/status```: Will get the current state of the program
- Equivalent to calling the get inventories, get orders and get product catalogs method

<br>

```http://localhost:5206/api/PCI/{id}```: Will get both the product catalog and inventory with the giving id
- Equivalent to calling the get product catalog by id and get inventory by id method 
