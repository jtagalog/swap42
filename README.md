# An API to Check Bike Thefts
### Features
- Provides an easy way to check bike thefts in a given city.
- Supports search by zipcode, address, city and coordinate.

**Bike Theft Search**
----
  Returns json data about the count of bike thefts in a given location.

* **URL**

  /BikeTheftSearch/:location

* **Method:**

  `GET`
  
*  **URL Params**

   **Required:**
 
   `location=[string]`

* **Data Params**

  None

* **Success Response:**

  * **Code:** 200 <br />
    **Content:** `{ "proximity": 14, "location": "Amsterdam, The Netherlands" }`

* **Sample Call:**

  ```javascript
    $.ajax({
      url: "/BikeTheftSearch/Amsterdam%2C%20The%20Netherlands",
      dataType: "json",
      type : "GET",
      success : function(r) {
        console.log(r);
      }
    });
  ```
