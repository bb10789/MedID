/**
 * Javascript for MedID API test website. Shows off all the API functionality.
 */
"use strict";

(function () {
  window.addEventListener("load", initialize);
  const URL = "https://med-id.azurewebsites.net/api";

  /**
   * Adds functionality to all the buttons.
   */
  function initialize() {
    id("all_user_ids_btn").addEventListener("click", getAllUserIds);
    id("user_id_btn").addEventListener("click", displayUserIdForm);
    id("user_id_form").addEventListener("submit", function (e) {
      e.preventDefault();
      getUserId();
    });
    id("all_interactions_btn").addEventListener("click", getAllInteractions);
    id("interaction_id_btn").addEventListener("click", displayInteractionIdForm);
    id("interaction_id_form").addEventListener("submit", function (e) {
      e.preventDefault();
      getInteractionId();
    });
    id("report_interaction_btn").addEventListener("click", displayInteractionForm);
    id("interaction_form").addEventListener("submit", function (e) {
      e.preventDefault();
      submitInteraction();
    });
    id("register_user_btn").addEventListener("click", displayRegisterUserForm);
    id("register_user_form").addEventListener("submit", function (e) {
      e.preventDefault();
      registerUser();
    });
  }

  function getAllUserIds() {
    hideAllViews();
    fetch(URL + "/UserIds")
      .then(checkStatus)
      .then((res) => res.json())
      .then(displayAllUserIds)
      .catch(handleRequestError);
  }

  function displayAllUserIds(userIds) {
    for (const person of userIds) {
      console.log(person);
      let text = gen("p");
      text.textContent =
        "ID: " +
        person.id +
        "\r\nFirst Name: " +
        person.fname +
        "\r\nLast Name: " +
        person.lname +
        "\r\nEmail: " +
        person.email +
        "\r\nLocation: " +
        person.location +
        "\r\nPhone Number: " +
        person.phone +
        "\r\n";
      id("display").appendChild(text);
    }
  }

  function getUserId() {
    document.getElementById("display").innerHTML = "";
    let id = document.getElementById("user_id").value;
    fetch(URL + "/UserIds/" + id)
      .then(checkStatus)
      .then((res) => res.json())
      .then(displayUserId)
      .catch(handleRequestError);
  }

  function displayUserId(person) {
    let text = gen("p");
    text.textContent =
      "ID: " +
      person.id +
      "\r\nFirst Name: " +
      person.fname +
      "\r\nLast Name: " +
      person.lname +
      "\r\nEmail: " +
      person.email +
      "\r\nLocation: " +
      person.location +
      "\r\nPhone Number: " +
      person.phone +
      "\r\n";
    id("display").appendChild(text);
  }

  function getAllInteractions() {
    hideAllViews();
    fetch(URL + "/Interactions")
      .then(checkStatus)
      .then((res) => res.json())
      .then(displayAllInteractions)
      .catch(handleRequestError);
  }

  function displayAllInteractions(interactions) {
    for (const interaction of interactions) {
      let msg = gen("p");
      msg.textContent =
        "Interaction " +
        interaction.interactionId +
        " happened on " +
        interaction.interDate +
        " between Person " +
        interaction.id1 +
        " and Person " +
        interaction.id2 +
        "\r\n";
      id("display").appendChild(msg);
    }
  }

  function getInteractionId() {
    document.getElementById("display").innerHTML = "";
    let id = document.getElementById("interaction_id").value;
    fetch(URL + "/Interactions/" + id)
      .then(checkStatus)
      .then((res) => res.json())
      .then(displayInteraction)
      .catch(handleRequestError);
  }

  function displayInteraction(interaction) {
    let msg = gen("p");
    msg.textContent =
      "Interaction " +
      interaction.interactionId +
      " happened on " +
      interaction.interDate +
      " between Person " +
      interaction.id1 +
      " and Person " +
      interaction.id2 +
      "\r\n";
    id("display").appendChild(msg);
  }

  function submitInteraction() {
    hideAllViews();
    let id1 = id("id1").value;
    let id2 = id("id2").value;
    let params = {
      id1: id1,
      id2: id2,
    };
    console.log(params);
    fetch(URL + "/Interactions", {
      method: "POST",
      headers: {
        Accept: "application/json, text/plain, */*",
        "Content-Type": "application/json",
      },
      body: JSON.stringify(params),
    })
      .then(checkStatus)
      .then((res) => res.json())
      .then(displayInteractionSuccess)
      .catch(handleRequestError);
  }

  function displayInteractionSuccess(interaction) {
    console.log(interaction);
    let msg = gen("p");
    msg.textContent = "Your interaction has been successfully submitted, the id is " + interaction.interactionId;
    id("display").appendChild(msg);
  }

  function registerUser() {
    hideAllViews();
    let fname = id("fname").value;
    let lname = id("lname").value;
    let phone = id("phone").value;
    let email = id("email").value;
    let location = id("location").value;
    let params = {
      fname: fname,
      lname: lname,
      phone: phone,
      email: email,
      location: location,
    };
    console.log(params);
    fetch(URL + "/UserIds", {
      method: "POST",
      headers: {
        Accept: "application/json, text/plain, */*",
        "Content-Type": "application/json",
      },
      body: JSON.stringify(params),
    })
      .then(checkStatus)
      .then((res) => res.json())
      .then(displayRegistrationMsg)
      .catch(handleRequestError);
  }

  function displayRegistrationMsg(user) {
    console.log(user);
    let msg = gen("p");
    msg.textContent = "Registration successful, your ID is " + user.id;
    id("display").appendChild(msg);
  }

  function displayUserIdForm() {
    hideAllViews();
    id("user_id_view").classList.remove("hidden");
  }

  function displayInteractionIdForm() {
    hideAllViews();
    id("interaction_id_view").classList.remove("hidden");
  }

  function displayInteractionForm() {
    hideAllViews();
    id("report_interaction_view").classList.remove("hidden");
  }

  function displayRegisterUserForm() {
    hideAllViews();
    id("register_user_view").classList.remove("hidden");
  }

  function hideAllViews() {
    id("display").innerHTML = "";
    for (const view of getClass("view")) {
      view.classList.add("hidden");
    }
  }

  /**
   * Helper function to return the response's result text if successful, otherwise
   * returns the rejected Promise result with an error status and corresponding text
   * @param {object} response - response to check for success/error
   * @return {object} - valid response if response was successful, otherwise rejected
   *                    Promise result
   */
  function checkStatus(response) {
    if (response.ok) {
      return response;
    } else {
      throw Error(response.statusText);
    }
  }

  /**
   * When an error has occurred getting data from the server, the error is displayed
   * on screen as well as additional information.
   * @param {Error} error - error that occurred
   */
  function handleRequestError(error) {
    console.log(error);
    id("display").innerHTML = "";
    let errorMsg = gen("p");
    errorMsg.textContent = "An error has occurred, if an ID was inputed, it may be invalid";
    id("display").appendChild(errorMsg);
  }

  function getClass(className) {
    return document.getElementsByClassName(className);
  }

  /**
   * Returns the first element that matches the given CSS selector.
   * @param {string} query - CSS query selector.
   * @returns {object} The first DOM object matching the query.
   */
  function qs(query) {
    return document.querySelector(query);
  }

  /**
   * Returns the element that has the ID attribute with the specified value.
   * @param {string} id - element ID
   * @returns {object} DOM object associated with id.
   */
  function id(id) {
    return document.getElementById(id);
  }

  /**
   * Returns element with specified tag name and clears the display.
   * @param {string} tagName - name of element to create
   * @returns {object} element of desired tag
   */
  function gen(tagName) {
    return document.createElement(tagName);
  }
})();
