delete from pap_Photos
GO

delete from pap_Albums
GO

exec pap_InsertAlbum 0, 'offwhite', 'Test 1', '1', '1'
exec pap_InsertAlbum 0, 'offwhite', 'Test 2', '1', '0'
exec pap_InsertAlbum 0, 'offwhite', 'Test 3', '0', '1'
exec pap_InsertAlbum 0, 'offwhite', 'Test 4', '0', '0'
GO

exec pap_InsertPhoto 0, 1, 'Photo 1', '02/11/2006', '1', '1', 0, 0, '', '', '', '', 1, 1
exec pap_InsertPhoto 0, 1, 'Photo 2', '02/11/2006', '1', '0', 0, 0, '', '', '', '', 1, 1
exec pap_InsertPhoto 0, 1, 'Photo 3', '02/11/2006', '0', '1', 0, 0, '', '', '', '', 1, 1
exec pap_InsertPhoto 0, 1, 'Photo 4', '02/11/2006', '0', '0', 0, 0, '', '', '', '', 1, 1
GO

