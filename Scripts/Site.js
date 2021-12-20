var myPDF = new PDFObject({
    url: '//pupool.ke/uploads/5_1638012066.pdf',
    pdfOpenParams: {
        view: 'Fit',
        scrollbars: '0',
        toolbar: '0',
        statusbar: '0',
        navpanes: '0'
    }
}).embed('pdf1');