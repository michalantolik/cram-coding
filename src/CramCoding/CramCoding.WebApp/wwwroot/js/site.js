/*************************************************************************
 * CONTROLLER: AdminPost
 * VIEW:       AddPost
*************************************************************************/

function updateFormSubmissionDateTime() {

    let currentDateTimeIso = new Date().toISOString();
    $('input#FormSumbissionDateTimeUtc').val(currentDateTimeIso);

}

/*************************************************************************
 * USED IN VIEWS:
 *
 * Please update the list below as you use this method in new places:
 * 
 * - ListCategories
 * - ListPosts
 * 
*************************************************************************/

function showEntityDetails(controller, method, id) {

    window.location = `/${controller}/${method}/${id}`;

}
