-- photos
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'F' 
  AND name = 'FK_pap_Photos_pap_Albums')
  BEGIN
    print 'Dropping FK_pap_Photos_pap_Albums'
    ALTER TABLE dbo.pap_Photos
      DROP CONSTRAINT FK_pap_Photos_pap_Albums
  END
GO
