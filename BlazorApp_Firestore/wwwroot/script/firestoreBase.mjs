import { initializeApp } from "./firebase-app.js";

import {
    getFirestore,
    collection,
    addDoc,
    getDocs,
    deleteDoc,
    doc
} from "./firebase.js";

// Firebase configuration details
// replace this configuration with your own configuration details
const firebaseConfig = {
    apiKey: "AIzaSyCkdQgGr5NxJpzBdHsCKPEupktZWaHwsIY",
    authDomain: "blazor-user-app.firebaseapp.com",
    projectId: "blazor-user-app",
    storageBucket: "blazor-user-app.firebasestorage.app",
    messagingSenderId: "245766229073",
    appId: "1:245766229073:web:38ecc483e6cbffb41e7c70"
};


// Initialize Firebase with the configuration details
const app = initializeApp(firebaseConfig);

// Initialize Cloud Firestore and get a reference to the service
const db = getFirestore(app);


async function getUsersTwo() {
    console.log("getUsersTwo called-----");
    const querySnapshot = await getDocs(collection(db, "users"));
    let dataArray = querySnapshot.docs.map((doc) => ({
        id: doc.id,
        userName: doc.get("name"),
    }));

    return dataArray;
}


// Define a function to add a new user to the Firestore database
window.addCustomer = async (userJSON) => {
    try {
        const docRef = await addDoc(collection(db, "customer"), {
            firstName: userJSON.FirstName,
            lastName: userJSON.LastName,
            email: userJSON.Email,
            phone: userJSON.Phone,

        });
        console.log("Document written with ID: ", docRef.id);
    } catch (e) {
        console.error("Error adding document: ", e);
    }
};

// Define a function to get all the users from the Firestore database
window.getUsers = async () => {
    const querySnapshot = await getDocs(collection(db, "customer"));
    let dataArray = querySnapshot.docs.map((doc) => ({
        id: doc.id,
        firstName: doc.get("firstName") ?? null,
        lastName: doc.get("lastName") ?? null,
        email: doc.get("email") ?? null,
    }));

    return dataArray;
};

// Define a function to delete a user from the Firestore database
window.deleteUser = async (userId) => {
    try {
        await deleteDoc(doc(db, "users", userId));
        console.log("Document with ID", userId, "deleted successfully.");
    } catch (e) {
        console.error("Error deleting document: ", e);
    }
};
