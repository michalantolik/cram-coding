function updateFormSubmissionDateTime() {

    let currentDateTimeIso = new Date().toISOString();
    $('input#FormSumbissionDateTimeUtc').val(currentDateTimeIso);

}
