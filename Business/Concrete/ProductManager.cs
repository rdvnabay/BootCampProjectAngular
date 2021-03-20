using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;
        public ProductManager(IProductDal productDal,
            ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }
        #region Add
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            var result = BusinessRules.Run(CheckIfProductNameAlreadyExist(product.ProductName),
                  CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                  CheckIfCategoryLimitExceded());
            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }
        #endregion

        public List<Product> GetAll()
        {
            return _productDal.GetAll();

        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(x => x.CategoryId == id);
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(x => x.ProductId == productId);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }

        public List<Product> GetUnitePrice(decimal min, decimal max)
        {
            return _productDal.GetAll(x => x.UnitPrice >= 50 && x.UnitPrice <= 100);
        }

        IDataResult<List<Product>> IProductService.GetAll()
        {
            throw new NotImplementedException();
        }

        IDataResult<List<Product>> IProductService.GetAllByCategoryId(int id)
        {
            throw new NotImplementedException();
        }

        IDataResult<Product> IProductService.GetById(int productId)
        {
            throw new NotImplementedException();
        }

        IDataResult<List<ProductDetailDto>> IProductService.GetProductDetails()
        {
            throw new NotImplementedException();
        }

        IDataResult<List<Product>> IProductService.GetUnitePrice(decimal min, decimal max)
        {
            throw new NotImplementedException();
        }


        //Business Rules Methods
        #region Business Rules 
        private IResult CheckIfProductNameAlreadyExist(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExist);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result > 10)
            {
                new ErrorResult(Messages.CheckIfProductCountOfCategoryCorrect);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }
        #endregion
    }
}
