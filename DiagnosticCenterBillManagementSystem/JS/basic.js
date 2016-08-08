function demoPDF() {
    var doc = new jsPDF();
    doc.text(10, 10, 'Diagnostic Center Billing System');
    doc.text(10, 20, 'Patient Name:');
    doc.text(10, 30, 'Date Of Birth:');
    doc.text(10, 40, 'Mobile No:');
    doc.text(10, 50, 'Test type:');
    doc.text(10, 60, 'Test fee:');

    //doc.setFontType("bold");
    //doc.setTextColor(255, 0, 0); //set font color to red  
    doc.text(60, 20, document.getElementById("patientNameTextBox").value); //append first name in pdf  
    doc.text(60, 30, document.getElementById("dateOfBirthTextBox").value); //append last name in pdf  
    //doc.setFont("times");
    //doc.setFontType("italic");
    doc.text(60, 40, document.getElementById("mobileNoTextBox").value); //append email id in pdf  
    doc.text(60, 50, document.getElementById("selectTestDropDownList").value); //append last name in pdf  
    //doc.select(60, 50, document.getElementById("selectTestDropDownList").selectedItem);
    doc.text(60, 60, document.getElementById("fEETextBox").value); //append last name in pdf  
    //doc.addPage(); // add new page in pdf  
    //doc.setTextColor(165, 0, 0);
    //doc.text(10, 20, 'extra page to write');
    doc.save('Test bill.pdf'); // Save the PDF with name "katara"...  
}