using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCardDal;
        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public IResult Add(CreditCard creditCard)
        {
            var cards = _creditCardDal.GetAll();
            foreach (var card in cards)
            {
                if(card.UserId == creditCard.UserId)
                {
                    creditCard.Id = card.Id;
                    _creditCardDal.Update(creditCard);
                    return new SuccessResult(Messages.Success);
                }
            }
            _creditCardDal.Add(creditCard);
            return new SuccessResult(Messages.Success);
        }

        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(), Messages.Success);
        }

        public IDataResult<CreditCard> GetByUserId(int id)
        {
            return new SuccessDataResult<CreditCard>(_creditCardDal.Get(c => c.UserId == id), Messages.Success);
        }

        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult(Messages.Success);
        }
    }
}
