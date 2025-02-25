﻿namespace HeroesAPI.Repository
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private readonly MainDbContext _msSql;

        private readonly SqliteContext _sqlite;

        public IHeroRepository HeroRepository { get; }

        public IAuthRepository UserRepository { get; }

        public IEmailSenderRepository EmailSenderRepository { get; }

        public IBarcodeRepository BarcodeRepository { get; }

        public IQRCodeRepository QRCodeRepository { get; }

        public ISeriLogRepository SeriLogRepository { get; }

        public IAuthRepository AuthRepository { get; }

        public UnitOfWorkRepository(MainDbContext msqlDbContext, SqliteContext sqliteContext,
            IHeroRepository heroRepository,
            IAuthRepository userRepository,
            IEmailSenderRepository emailSenderRepository,
            IBarcodeRepository barcodeRepository,
            IQRCodeRepository qRCodeRepository,
            ISeriLogRepository seriLogRepository,
            IAuthRepository authRepository)
        {
            _msSql = msqlDbContext;
            _sqlite = sqliteContext;
            HeroRepository = heroRepository;
            UserRepository = userRepository;
            EmailSenderRepository = emailSenderRepository;
            BarcodeRepository = barcodeRepository;
            QRCodeRepository = qRCodeRepository;
            SeriLogRepository = seriLogRepository;
            AuthRepository = authRepository;
        }

        public async Task CommitAll()
        {
            var transaction = _msSql.Database.BeginTransaction();
            try
            {
                Task<int>? saveToDb = _msSql.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                transaction?.Rollback();
            }
        }

        protected virtual void DisposeMsql(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            if (_msSql == null)
            {
                return;
            }

            _msSql.Dispose();
        }

        protected virtual void DisposeSqlite(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            if (_msSql == null)
            {
                return;
            }

            _msSql.Dispose();
        }


        public void Dispose()
        {
            DisposeMsql(true);
            DisposeSqlite(true);
            GC.SuppressFinalize(this);
        }



    }
}
